using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace Mongo
{
    public class MongoConfigurator : IMongoConfigurator
    {
        public void Initialize()
		{
			RegisterConventions();
		}

		private static void RegisterConventions()
		{
            BsonSerializer.RegisterSerializer(typeof(decimal), 
                new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), 
                new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
			ConventionRegistry.Register("ProductsConventions", new MongoConvention(), x => true);
		}

		private class MongoConvention : IConventionPack
		{
			public IEnumerable<IConvention> Conventions => new List<IConvention>
			{
				new IgnoreExtraElementsConvention(true),
				new EnumRepresentationConvention(BsonType.String),
				new CamelCaseElementNameConvention()
			};
        } 
    }
}