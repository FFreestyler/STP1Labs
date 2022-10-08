using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab9;

namespace TestFractionEditor
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFractionEditor()
        {
            var editor = new FractionEditor();

            var actual = editor.getNumber();
            var expected = "0/1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFractionEditorIsNull()
        {
            var editor = new FractionEditor();

            var actual = editor.IsNull();
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFractionEditorAppendNumber()
        {
            var editor = new FractionEditor();

            var expected = editor.appendNumber(3);
            var actual = "0/13";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestFractionEditorAppendZero()
        {
            var editor = new FractionEditor();

            var expected = editor.appendZero();
            var actual = "0/10";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestFractionEditorPopNumber()
        {
            var editor = new FractionEditor();
            editor.appendNumber(5);
            editor.appendNumber(8);
            editor.popNumberBack();

            var expected = editor.getNumber();
            var actual = "0/15";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestFractionEditorClear()
        {
            var editor = new FractionEditor();
            editor.appendNumber(5);
            editor.appendNumber(8);
            editor.clear();

            var expected = editor.getNumber();
            var actual = "0/1";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestFractionEditorGetNumber()
        {
            var editor = new FractionEditor();

            var expected = editor.getNumber();
            var actual = "0/1";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestFractionEditorSetNumber()
        {
            var editor = new FractionEditor();
            editor.setNumber("1/2");

            var expected = editor.getNumber();
            var actual = "1/2";

            Assert.IsTrue(expected == actual);
        }
    }
}