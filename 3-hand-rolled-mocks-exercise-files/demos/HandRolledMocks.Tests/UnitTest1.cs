using System;
using NUnit.Framework;
using PluralSight.HandRolledMocks.Code;

namespace HandRolledMocks.Tests
{
    [TestFixture]
    public class When_logging
    {
        private MockScrubber _mockScrubber;
        private MockLogHeader _mockLogHeader;
        private MockLogFooter _mockLogFooter;
        private MockConfigurer _mockConfigurer;

        [SetUp]
        public void Setup()
        {
            _mockScrubber = new MockScrubber();
            _mockLogHeader = new MockLogHeader();
            _mockLogFooter = new MockLogFooter();
            _mockConfigurer = new MockConfigurer();

            var logger = new Logging(_mockScrubber, _mockLogHeader, _mockLogFooter, _mockConfigurer);

            logger.CreateEntryFor("my message", LogLevel.Info);
        }

        [Test]
        public void sensitive_data_should_be_scrubbed_from_the_log_message()
        {
            Assert.That(_mockScrubber.FromWasCalled);
        }
    }

    internal class MockConfigurer : IConfigureSystem
    {
        public MockConfigurer()
        {
        }

        public bool LogStackFor(LogLevel logLevel)
        {
            //throw new NotImplementedException();
            return true;
        }
    }

    internal class MockLogFooter : ICreateLogEntryFooter
    {
        public MockLogFooter()
        {
        }

        public void For(LogLevel logLevel)
        {
            //throw new NotImplementedException();
        }
    }

    internal class MockLogHeader : ICreateLogEntryHeaders
    {
        public MockLogHeader()
        {
        }

        public void For(LogLevel logLevel)
        {
            //throw new NotImplementedException();
        }
    }

    public class MockScrubber : IScrubSensitiveData
    {
        public bool FromWasCalled { get; private set; }
        public string From(string messageToScrub)
        {
            FromWasCalled = true;

            return string.Empty;
        }
    }
}
