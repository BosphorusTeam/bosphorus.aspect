using System;
using System.ComponentModel;

namespace Bosphorus.Aspect.Debug.PropertyWrapper
{
    public class CustomPropertyDescriptor<TComponent>: PropertyDescriptor where TComponent : class
    {
        private readonly Func<TComponent, object> valueGetter;
        private readonly Action<TComponent, object> valueSetter;

        public CustomPropertyDescriptor(string name, Type type, Func<TComponent, object> valueGetter, Action<TComponent, object> valueSetter, params Attribute[] attributes)
            : base(name, attributes)
        {
            this.valueGetter = valueGetter;
            this.valueSetter = valueSetter;
            PropertyType = type;
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            TComponent owner = component as TComponent;
            var result = valueGetter(owner);
            return result;
        }

        public override void SetValue(object component, object value)
        {
            TComponent owner = component as TComponent;
            valueSetter(owner, value);
        }

        public override void ResetValue(object component)
        {
            SetValue(component, null);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override Type ComponentType => typeof(TComponent);

        public override bool IsReadOnly => false;

        public override Type PropertyType { get; }
    }
}
