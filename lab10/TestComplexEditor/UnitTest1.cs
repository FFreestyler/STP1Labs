using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab10;

namespace TestComplexEditor
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestComplexEditor()
        {
            var editor = new ComplexEditor();

            var actual = editor.getNumber();
            var expected = "0+i*0";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestComplexEditorIsNull()
        {
            var editor = new ComplexEditor();

            var actual = editor.IsNull();
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestComplexEditorAppendNumber()
        {
            var editor = new ComplexEditor();

            var expected = editor.appendNumber(3);
            var actual = "0+i*03";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestComplexEditorAppendZero()
        {
            var editor = new ComplexEditor();

            var expected = editor.appendZero();
            var actual = "0+i*00";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestComplexEditorPopNumber()
        {
            var editor = new ComplexEditor();
            editor.appendNumber(5);
            editor.appendNumber(8);
            editor.popNumberBack();

            var expected = editor.getNumber();
            var actual = "0+i*05";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestComplexEditorClear()
        {
            var editor = new ComplexEditor();
            editor.appendNumber(5);
            editor.appendNumber(8);
            editor.clear();

            var expected = editor.getNumber();
            var actual = "0+i*0";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestComplexEditorGetNumber()
        {
            var editor = new ComplexEditor();

            var expected = editor.getNumber();
            var actual = "0+i*0";

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestComplexEditorSetNumber()
        {
            var editor = new ComplexEditor();
            editor.setNumber("5+i*13");

            var expected = editor.getNumber();
            var actual = "5+i*13";

            Assert.IsTrue(expected == actual);
        }
    }
}