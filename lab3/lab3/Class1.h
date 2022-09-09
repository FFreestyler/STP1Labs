#pragma once

#include <iostream>
#include <vector>

class Class1 {
public:
	int numberRankCount(int number) {
		int rankCount = 0;
		while (number) {
			number /= 10;
			rankCount++;
		}
		return rankCount;
	}

	int shiftInt(int number, int shiftCount, bool direction = true) {
		int rankCount = numberRankCount(number);
		int position = pow(10, rankCount - 1);


		if (!direction) {
			for (int i = 0; i < shiftCount; i++) {
				int tmp = number / position;
				number %= position;
				number = number * 10 + tmp;
			}
		}
		else {
			for (int i = 0; i < shiftCount; i++) {
				int tmp = number % 10;
				number /= 10;
				number = tmp * position + number;
			}
		}
		return number;
	}

	int fibNumber(int n) {
		int a = 0;
		int b = 1;
		for (int i = 0; i < n; i++) {
			a = a + b;
			b = a - b;
		}
		return a;
	}

	int delDecimalInt(int number, int position, int count) {
		int rankCount = numberRankCount(number);

		int zeroCount = pow(10, rankCount - position - count);

		int lastPart = number % zeroCount;
		int firstPart = number / pow(10, rankCount - position);

		return firstPart * zeroCount + lastPart;
	}

	int evenSumMatrixEl(std::vector<std::vector<int>> matrix) {
		int sum = 0;
		for (int i = 0; i < matrix.size(); i++) {
			if (matrix[i].size() == 0) {
				break;
			}
			for (int j = 0; j < matrix[i].size() - i - 1; j++) {
				if (!(i % 2) && !(j % 2)) {
					sum += matrix[i][j];
				}
			}
		}
		return sum;
	}
};

