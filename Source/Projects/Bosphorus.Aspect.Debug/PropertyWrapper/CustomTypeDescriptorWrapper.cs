using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Bosphorus.Aspect.Debug.PropertyWrapper
{
    public class CustomTypeDescriptorWrapper : CustomTypeDescriptor, INotifyPropertyChanged
    {
        #region Static Constructor

        private static readonly IDictionary<Type, PropertyDescriptorCollection> propertyCache;

        static CustomTypeDescriptorWrapper()
        {
            propertyCache = new Dictionary<Type, PropertyDescriptorCollection>();
        }

        private static PropertyDescriptorCollection GetTypeProperties(Type type)
        {
            lock (propertyCache)
            {
                PropertyDescriptorCollection properties;
                if (!propertyCache.TryGetValue(type, out properties))
                {
                    var list = new List<PropertyDescriptor>();
                    GetTypeProperties(list, type);
                    properties = new PropertyDescriptorCollection(list.ToArray());
                    propertyCache.Add(type, properties);
                }
                return properties;
            }
        }

        private static void GetTypeProperties(ICollection<PropertyDescriptor> list, Type type)
        {
            var fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var fieldInfo in fieldInfos)
            {
                bool isSimple = fieldInfo.FieldType.IsSimpleType();
                var dataRecordProperty = isSimple ? BuildSimpleProperty(fieldInfo) : BuildWrappedProperty(fieldInfo);
                list.Add(dataRecordProperty);
            }

            Type baseType = type.BaseType;
            if (baseType == typeof(object))
            {
                return;
            }

            GetTypeProperties(list, baseType);
        }

        private static PropertyDescriptor BuildWrappedProperty(FieldInfo fieldInfo)
        {
            Func<CustomTypeDescriptorWrapper, object> propertyGetter = proxy => new CustomTypeDescriptorWrapper(fieldInfo.GetValue(proxy.Instance));
            Action<CustomTypeDescriptorWrapper, object> propertySetter = (proxy, value) => fieldInfo.SetValue(proxy.Instance, value);
            var dataRecordProperty = new CustomPropertyDescriptor<CustomTypeDescriptorWrapper>(fieldInfo.Name, typeof(CustomTypeDescriptorWrapper), propertyGetter, propertySetter, new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
            return dataRecordProperty;
        }

        private static CustomPropertyDescriptor<CustomTypeDescriptorWrapper> BuildSimpleProperty(FieldInfo fieldInfo)
        {
            Func<CustomTypeDescriptorWrapper, object> propertyGetter = proxy => fieldInfo.GetValue(proxy.Instance);
            Action<CustomTypeDescriptorWrapper, object> propertySetter = (proxy, value) => fieldInfo.SetValue(proxy.Instance, value);
            var dataRecordProperty = new CustomPropertyDescriptor<CustomTypeDescriptorWrapper>(fieldInfo.Name, fieldInfo.FieldType, propertyGetter, propertySetter);
            return dataRecordProperty;
        }

        #endregion

        private readonly PropertyDescriptorCollection properties;

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomTypeDescriptorWrapper(object instance)
        {
            this.Instance = instance;

            properties = instance == null
                ? PropertyDescriptorCollection.Empty
                : GetTypeProperties(instance.GetType());
        }

        public void CheckAndNotify()
        {
            OnPropertyChanged(null);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Instance { get; }

        public override PropertyDescriptorCollection GetProperties() => GetProperties(null);

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return properties;
        }

        public override object GetPropertyOwner(PropertyDescriptor property)
        {
            return this;
        }
    }
}
