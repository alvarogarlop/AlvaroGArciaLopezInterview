﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TTCDictionary.UnitTests
{
    [TestFixture]
    public class LanguageDictionaryTest
    {
        private LanguageDictionary SUT;

        private Dictionary<string, string> list;

        [SetUp]
        public void Setup()
        {
            list = new Dictionary<string, string>();

            SUT = new LanguageDictionary(list);
        }

        [Test]
        public void When_adding_a_word_which_does_not_exist_should_return_true()
        {
            // Arrange.
            var word = "test";
            var lang = "English";

            // Act.
            var result = this.SUT.Add(lang, word);

            // Assert.
            Assert.IsTrue(result);

            var listCheck = this.list.FirstOrDefault(i => i.Key == lang && i.Value == word);

            Assert.IsTrue(listCheck.Key == lang);
            Assert.IsTrue(listCheck.Value == word);
        }

        [Test]
        public void When_adding_a_word_which_does_exist_but_in_a_different_language_should_return_true()
        {
            // Arrange.
            var word = "test";
            this.SUT.Add("English", word);

            // Act.
            var result = this.SUT.Add("German", word);

            // Assert.
            Assert.IsTrue(result);
        }

        [Test]
        public void When_adding_a_word_for_a_language_which_does_exist_should_return_false()
        {
            // Arrange.
            var word = "test";
            this.SUT.Add("English", word);

            // Act.
            var result = this.SUT.Add("English", "test2");

            // Assert.
            Assert.IsFalse(result);
        }

        [Test]
        public void When_adding_a_null_language_should_return_false()
        {
            // Arrange.
            var word = "test";
            var result = this.SUT.Add(null, word);

            // Assert.
            Assert.IsFalse(result);
        }

        [Test]
        public void When_checking_a_word_which_does_not_exist_should_return_false()
        {
            // Arrange.
            var word = "test";

            // Act.
            var result = this.SUT.Check("English", word);

            // Assert.
            Assert.IsFalse(result);
        }

        [Test]
        public void When_checking_a_word_which_does_exist_should_return_true()
        {
            // Arrange.
            var word = "test";
            this.SUT.Add("English", word);

            // Act.
            var result = this.SUT.Check("English", word);

            // Assert.
            Assert.IsTrue(result);
        }

        [Test]
        public void When_checking_a_word_which_null_language_should_return_false()
        {
            // Act.
            var result = this.SUT.Check(null, "test");

            // Assert.
            Assert.False(result);
        }

        [Test]
        public void When_searching_words_that_starts_with_test_should_return_a_list_of_words()
        {
            // Arrange.
            this.SUT.Add("English", "test1");
            this.SUT.Add("German", "test2");
            this.SUT.Add("Spanish", "test3");

            // Act.
            var result = this.SUT.Search("test");

            // Assert.
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void When_searching_words_that_starts_with_test_should_return_an_empty_list()
        {
            // Arrange.
            this.SUT.Add("English", "est1");
            this.SUT.Add("German", "est2");
            this.SUT.Add("Spanish", "est3");

            // Act.
            var result = this.SUT.Search("test");

            // Assert.
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void When_searching_words_with_null_value_should_return_an_empty_list()
        {
            // Arrange.
            this.SUT.Add("English", "est1");
            this.SUT.Add("German", "est2");
            this.SUT.Add("Spanish", "est3");

            // Act.
            var result = this.SUT.Search(null);

            // Assert.
            Assert.AreEqual(0, result.Count());
        }
    }
}
