using NetMicro.Http.Rest;
using Xunit;

namespace NetMicro.Http.Tests.Rest
{
    public class QueryTest
    {
        [Fact]
        public void SkipShouldReturnNullWhenQueryIsEmpty()
        {
            var restQuery = new Http.Rest.Query(QueryStringParser.Parse(""));

            Assert.Null(restQuery.Skip);
        }

        [Fact]
        public void SkipShouldReturnValueWhenInQueryIsDigit()
        {
            var restQuery = new Http.Rest.Query(QueryStringParser.Parse("?skip=3"));

            Assert.Equal(3, restQuery.Skip);
        }

        [Fact]
        public void SkipShouldThrowWhenInQueryIsNotDigit()
        {
            Assert.Throws<ParamIsNotNumberException>(() => 
                new Http.Rest.Query(QueryStringParser.Parse("?skip=xc")).Skip
            );
        }
        
        [Fact]
        public void GetLimitShouldReturnNullWhenQueryIsEmpty()
        {
            var restQuery = new Http.Rest.Query(QueryStringParser.Parse(""));

            Assert.Null(restQuery.GetLimit(23));
        }

        [Fact]
        public void GetLimitShouldReturnValueWhenInQueryIsDigit()
        {
            var restQuery = new Http.Rest.Query(QueryStringParser.Parse("?limit=3"));

            Assert.Equal(3, restQuery.GetLimit(23));
        }

        [Fact]
        public void GetLimitShouldReturnMaxValueWhenInQueryIsHigher()
        {
            var restQuery = new Http.Rest.Query(QueryStringParser.Parse("?limit=30"));

            Assert.Equal(23, restQuery.GetLimit(23));
        }

        [Fact]
        public void GetLimitShouldThrowWhenInQueryIsNotDigit()
        {
            Assert.Throws<ParamIsNotNumberException>(() => 
                new Http.Rest.Query(QueryStringParser.Parse("?limit=xc")).GetLimit(23)
            );
        }

        [Fact]
        public void FilterReturnEmptyDictionaryWhenQueryIsEmpty()
        {
            Assert.Empty(new Http.Rest.Query(QueryStringParser.Parse("")).Filter);
        }

        [Fact]
        public void FilterReturnEmptyDictionaryWhenInQueryIsNotDictionary()
        {
            var filters = new Http.Rest.Query(QueryStringParser.Parse("filter[]=x")).Filter;
            Assert.Empty(filters);
        }

        [Fact]
        public void FilterReturnFieldDictionaryWhenIsSetInQuery()
        {
            var filters = new Http.Rest.Query(QueryStringParser.Parse("filter[a]=x")).Filter;
            Assert.Equal("x", filters["a"]);
        }

        [Fact]
        public void OrderReturnEmptyDictionaryWhenInQueryIsNotDictionary()
        {
            var order = new Http.Rest.Query(QueryStringParser.Parse("sort[]=x")).Order;
            Assert.Empty(order);
        }

        [Fact]
        public void OrderReturnFieldDictionaryWhenIsSetInQuery()
        {
            var order = new Http.Rest.Query(QueryStringParser.Parse("sort[a]=asc")).Order;
            Assert.Equal("a", order[0].Field);            
            Assert.Equal(Order.Asc, order[0].Order);            
        }

        [Fact]
        public void OrderReturnFieldAscDictionaryWhenIsSetEmptyInQuery()
        {
            var order = new Http.Rest.Query(QueryStringParser.Parse("sort[a]=")).Order;
            Assert.Equal("a", order[0].Field);
            Assert.Equal(Order.Asc, order[0].Order);            
        }

        [Fact]
        public void OrderReturnFieldDescDictionaryWhenIsSetDescInQuery()
        {
            var order = new Http.Rest.Query(QueryStringParser.Parse("sort[a]=desc")).Order;
            Assert.Equal("a", order[0].Field);
            Assert.Equal(Order.Desc, order[0].Order);            
        }

        [Fact]
        public void OrderShouldReturnFieldsInOrder()
        {
            var order = new Http.Rest.Query(QueryStringParser.Parse("sort[x]=&sort[a]=")).Order;
            Assert.Equal("x", order[0].Field);
            Assert.Equal("a", order[1].Field);
        }

        [Fact]
        public void OrderShouldThrowWhenIncorrectValueIsSetInQuery()
        {
            Assert.Throws<IncorrectOrderingValue>(() =>
                new Http.Rest.Query(QueryStringParser.Parse("sort[a]=asdf")).Order
            );            
        }

        [Fact]
        public void GetFilterOrDefaultShouldReturnDefaultWhenFilterNotDefinedInQuery()
        {
            const string defaultValue = "s";

            var result = new Http.Rest.Query(QueryStringParser.Parse("")).GetFilterOrDefault("name", defaultValue);
            Assert.Equal(defaultValue, result);
        }     

        [Fact]
        public void GetFilterOrDefaultShouldReturnValueWhenFilterDefinedInQuery()
        {
            const string value = "s";

            var result = new Http.Rest.Query(QueryStringParser.Parse($"?filter[name]={value}")).GetFilterOrDefault("name", "s");
            Assert.Equal(value, result);
        }
    }
}