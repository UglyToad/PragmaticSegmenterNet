namespace PragmaticSegmenterNet.Tests.Annotator.Models
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public List<ExistingTest> ExistingTests { get; set; }
        
        public class ExistingTest
        {
            public string Sample { get; set; }

            public int Index { get; set; }
        }
    }
}
