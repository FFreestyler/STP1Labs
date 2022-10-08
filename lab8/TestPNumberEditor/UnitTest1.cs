using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab8;

namespace TestPNumberEditor
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPNumberEditor()
        {
            var editor = new PNumberEditor();

            var actual = editor.getNumber();
            var expected = "0";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPNumberEditorIsNull()
        {
            var editor = new PNumberEditor();

            var actual = editor.IsNull();
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPNumberAppendNumber()
        {
            var editor = new PNumberEditor();

            var expected = editor.appendNumber(5);
            var actual = "05";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestPNumberAppendZero()
        {
            var editor = new PNumberEditor();

            var expected = editor.appendZero();
            var actual = "00";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestPNumberPopNumberBack()
        {
            var editor = new PNumberEditor();
            editor.appendNumber(5);
            editor.appendNumber(8);
            editor.popNumberBack();

            var expected = editor.getNumber();
            var actual = "05";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestPNumberClear()
        {
            var editor = new PNumberEditor();
            editor.appendNumber(5);
            editor.appendNumber(8);
            editor.clear();

            var expected = editor.getNumber();
            var actual = "0";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestPNumberGetNumber()
        {
            var editor = new PNumberEditor();

            var expected = editor.getNumber();
            var actual = "0";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestPNumberSetNumber()
        {
            var editor = new PNumberEditor();
            editor.setNumber("12");

            var expected = editor.getNumber();
            var actual = "12";

            Assert.IsTrue(expected == actual);
        }
    }
}