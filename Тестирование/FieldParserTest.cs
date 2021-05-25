using NUnit.Framework;


namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        [TestCase(@"", new string[0])]// Нет полей
        [TestCase("''", new[] { "" })] // Пустое поле
        [TestCase("text", new[] { "text" })] // одно поле
        [TestCase(@"text     ", new[] { "text" })]// Пробелы в начале или в конце строки игнорируются
        [TestCase("hello world", new[] { "hello", "world" })] // больше одного поля. разделитель длинной в один пробел
        [TestCase("hello 'world'", new[] { "hello", "world" })] // Поле в кавычках после простого поля
        [TestCase("'hello' world", new[] { "hello", "world" })] // Простое поле после поля в кавычках
        [TestCase(@"hello   world", new[] { "hello", "world" })] // Разделитель длиной >1 пробела
        [TestCase(@"""'text'""", new[] { @"'text'" })] // Одинарные кавычки внутри двойных
        [TestCase(@"'""text""'", new[] { @"""text""" })] // Двойные кавычки внутри одинарных
        [TestCase(@"'te xt'", new[] { @"te xt" })] //Пробел внутри кавычек
        [TestCase(@"'te''xt'", new[] { @"te", "xt" })] //Разделитель без пробелов
        [TestCase(@"'text", new[] { @"text" })] // Нет закрывающей кавычки
        [TestCase(@"'te\'xt'", new[] { @"te'xt" })] // Экранированные одинарные кавычки внутри одинарных
        [TestCase(@"""te\\xt""", new[] { @"te\xt" })]// Экранированный обратный слэш внутри кавычек
        [TestCase(@"""te\""xt""", new[] { @"te""xt" })] // Экранированные двойные кавычки внутри двойных
        [TestCase(@"""text ", new[] { @"text " })] // Пробел в конце поля с незакрытой кавычкой
        [TestCase(@"'text\\'", new[] { @"text\" })] // Экранированный обратный слэш перед 
        [TestCase("a\"b c d e\"f", new[] { @"a", "b c d e", "f" })] // простое поле заканчивается когда начинается поле в кавычках
        [TestCase(" b ", new[] { @"b" })] // простое поле окружено пробелами
        public static void RunTests(string input, string[] expectedOutput)
        {
            // Тело метода изменять не нужно
            Test(input, expectedOutput);
        }
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }
    }
}

      