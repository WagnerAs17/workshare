using workshare.core.Domain;
using workshare.core.Extensions;

namespace workshare.core.ValuesObjects
{
    public class CPF
    {
        public const int TAMANHO = 11;
        public string Numero { get; private set; }
        public CPF(string numero)
        {
            if (!CpfValido(numero))
                throw new DomainException("O CPF informado é inválido");

            Numero = numero;
        }


        public static bool CpfValido(string cpf)
        {
            cpf = cpf.ApenasNumeros();

            if (cpf.Length > TAMANHO)
                return false;

            while (cpf.Length != TAMANHO)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < TAMANHO && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[TAMANHO];

            for (var i = 0; i < TAMANHO; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % TAMANHO;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != TAMANHO - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (TAMANHO - i) * numeros[i];

            resultado = soma % TAMANHO;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != TAMANHO - resultado)
                return false;

            return true;
        }
    }
}
