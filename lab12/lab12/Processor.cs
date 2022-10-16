using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace lab12
{
    public class Processor<T>
    {
        public enum Operation
        {
            None,
            Add,
            Sub,
            Mul,
            Div
        };

        public enum Func
        {
            Rev,
            Sqr,
        };

        private T LeftOpRes;
        private T RightOp;
        private Operation operation;

        public Processor()
        {
            pReset();
        }

        public void pReset()
        {
            LeftOpRes = default;
            RightOp = default;
            operation = Operation.None;
        }

        public void resetOperation()
        {
            operation = Operation.None;
        }

        public void performOperation()
        {
            dynamic l = LeftOpRes;
            dynamic r = RightOp;
            switch (operation)
            {
                case Operation.None:
                    break;
                case Operation.Add:
                    LeftOpRes = r + l;
                    break;
                case Operation.Sub:
                    LeftOpRes = l - r;
                    break;
                case Operation.Mul:
                    LeftOpRes = r * l;
                    break;
                case Operation.Div:
                    LeftOpRes = l / r;
                    break;
            }
        }

        public void performFunction(Func function)
        {
            dynamic l = LeftOpRes;
            dynamic r = RightOp;
            switch (function)
            {
                case Func.Rev:
                    RightOp = Math.ReciprocalEstimate(r);
                    break;
                case Func.Sqr:
                    RightOp = Math.Pow(r, 2);
                    break;
                default:
                    throw new Exception("Invalid Arguments");
            }
        }

        public T getLeftOperand()
        {
            return LeftOpRes;
        }

        public void setLeftOperand(T op)
        {
            LeftOpRes = op;
        }
        public T getRightOperand()
        {
            return RightOp;
        }
        public void setRightOperand(T op)
        {
            RightOp = op;
        }

        public Operation getState()
        {
            return operation;
        }

        public void setState(Operation st)
        {
            operation = st;
        }
    }
}
