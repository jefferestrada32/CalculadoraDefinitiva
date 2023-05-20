namespace CalculatorDef.Models
{
    public class CalculatorModel
    {


        public double PerformOperation(double operand1, double operand2, string operation)
        {
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    if (operand2 != 0)
                        result = operand1 / operand2;
                    else
                        throw new DivideByZeroException("Error: No es posible dividir por 0");
                    break;
                default:
                    throw new ArgumentException("Operacion invalida");
            }

            return result;
        }

    }
}
