namespace PragmaticSegmenterNet.Tests.Annotator.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;

    public class TestDataRepository
    {
        private static readonly object Locker = new object();

        public static IReadOnlyList<IndexViewModel.ExistingTest> GetExistingTests(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new InvalidOperationException("No XML file at: " + filename);
            }

            lock (Locker)
            {
                var result = new List<IndexViewModel.ExistingTest>();

                var root = XElement.Load(filename);
                var allTests = root.Elements("test");

                foreach (var test in allTests)
                {
                    var input = test.Element("input")?.Value;

                    result.Add(new IndexViewModel.ExistingTest
                    {
                        Index = result.Count,
                        Sample = input?.Length > 70 ? input.Substring(0, 70) : input
                    });
                }

                return result;
            }
        }

        public static void SaveNewTest(string filename, string input, string[] sentences)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            if (!File.Exists(filename))
            {
                throw new InvalidOperationException("No XML file at: " + filename);
            }

            lock (Locker)
            {
                var root = XElement.Load(filename, LoadOptions.PreserveWhitespace);

                var newTest = new XElement("test", new XElement("input", input));
                var expected = new XElement("expected");

                var count = 0;
                foreach (var sentence in sentences)
                {
                    if (string.IsNullOrWhiteSpace(sentence))
                    {
                        continue;
                    }

                    expected.Add(new XElement("sentence", sentence));
                    count++;
                }

                if (count == 0)
                {
                    return;
                }

                newTest.Add(expected);

                root.Add(newTest);
                root.Save(filename, SaveOptions.None);
            }
        }
    }
}
