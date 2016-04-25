using Bosphorus.Serialization.Core.Serializer.Json;

namespace Bosphorus.Aspect.Core.Demo
{
    public class DemoJsonSerializer<TModel>: IJsonSerializer<TModel>
    {
        public string Serialize(TModel model)
        {
            return model.ToString();
        }

        public TModel Deserialize(string input)
        {
            return default(TModel);
        }
    }
}