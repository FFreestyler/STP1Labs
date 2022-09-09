#include "pch.h"
#include "CppUnitTest.h"
#include "../lab3/Class1.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{
	TEST_CLASS(UnitTest1)
	{
	public:
		Class1 modudeClass;
		TEST_METHOD(TestShiftIntLeft)
		{
			auto actual = modudeClass.shiftInt(12345, 3);
			auto expected = 34512;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestShiftIntRight)
		{
			auto actual = modudeClass.shiftInt(12345, 2);
			auto expected = 45123;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestShiftIntWithoutShift)
		{
			auto actual = modudeClass.shiftInt(12345, 0);
			auto expected = 12345;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestFibNumber)
		{
			auto actual = modudeClass.fibNumber(5);
			auto expected = 5;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestFibNumberWithZero)
		{
			auto actual = modudeClass.fibNumber(0);
			auto expected = 0;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestDelDecimalInt)
		{
			auto actual = modudeClass.delDecimalInt(123456, 2, 2);
			auto expected = 1256;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestDelDecimalIntWithZero)
		{
			auto actual = modudeClass.delDecimalInt(0, 0, 0);
			auto expected = 0;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestEvenSumMatrixEl)
		{
			std::vector<std::vector<int>> matrix{ {1,2,3},{4,5,6},{7,8,9} };
			auto actual = modudeClass.evenSumMatrixEl(matrix);
			auto expected = 1;

			Assert::AreEqual(expected, actual);
		}
		TEST_METHOD(TestEvenSumMatrixElWithouEl)
		{
			std::vector<std::vector<int>> matrix{ { },{ } };
			auto actual = modudeClass.evenSumMatrixEl(matrix);
			auto expected = 0;

			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(TestNumberRankCount)
		{
			auto actual = modudeClass.numberRankCount(123456);
			auto expected = 6;

			Assert::AreEqual(expected, actual);
		}
	};
}
