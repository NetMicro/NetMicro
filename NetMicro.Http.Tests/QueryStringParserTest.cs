using Xunit;

namespace NetMicro.Http.Tests
{
    public class QueryStringParserTest
    {
        [Fact]
        public void ParseEmptyQueryStringShouldReturnEmptyDictionary()
        {
            var url = new Url("GET", "https://localhost:80/");
            var query = QueryStringParser.Parse(url.Query);
            
            Assert.Empty(query.ToList());
        }

        [Fact]
        public void ParseQueryStringShouldReturnValue()
        {
            var url = new Url("GET", "https://localhost:80/?field=xvalue");
            var query = QueryStringParser.Parse(url.Query);
            
            Assert.Equal("xvalue", query.GetValue("field"));
        }

        [Fact]
        public void ParseQueryStringShouldReturnEmptyValue()
        {
            var url = new Url("GET", "https://localhost:80/?field=");
            var query = QueryStringParser.Parse(url.Query);
            
            Assert.Equal("", query.GetValue("field"));
        }

        [Fact]
        public void ParseQueryStringShouldRewriteValueWithLastOccurence()
        {
            var url = new Url("GET", "https://localhost:80/?field=asd&field=acd&field=axd");
            var query = QueryStringParser.Parse(url.Query);
            
            Assert.Equal("axd", query.GetValue("field"));
        }

        [Fact]
        public void ParseQueryStringShouldReturnArrayValueWhenFieldContainsBrackets()
        {
            var url = new Url("GET", "https://localhost:80/?field[]=asd&field[]=acd&field[]=axd");
            var query = QueryStringParser.Parse(url.Query);
            
            Assert.Equal("axd", query.GetValue("field[]"));
            Assert.Equal(new[] { "asd", "acd", "axd" }, query.GetValues("field[]"));
        }

        [Fact]
        public void ParseQueryStringShouldReturnArrayValue()
        {
            var url = new Url("GET", "https://localhost:80/?field=asd&field=acd&field=axd");
            var query = QueryStringParser.Parse(url.Query);
            
            Assert.Equal("axd", query.GetValue("field"));
            Assert.Equal(new[] { "asd", "acd", "axd" }, query.GetValues("field"));
        }

        [Fact]
        public void ParseQueryStringShouldReturnDictionary()
        {
            var url = new Url("GET", "https://localhost:80/?field[a]=asd&field[b]=acd&field[c]=axd");
            var query = QueryStringParser.Parse(url.Query);
            
            Assert.Equal("asd", query.GetValue("field[a]"));
            Assert.Equal("acd", query.GetValue("field[b]"));
            Assert.Equal("axd", query.GetValue("field[c]"));
            Assert.Equal(3, query.GetDictionary("field").Count);
            Assert.Equal("asd", query.GetDictionary("field")["a"]);
            Assert.Equal("acd", query.GetDictionary("field")["b"]);
            Assert.Equal("axd", query.GetDictionary("field")["c"]);
        }
    }
}