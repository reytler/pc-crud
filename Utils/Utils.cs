namespace crudpcapi.Utils;

public static class Util
{
    public static bool ValidateCpf(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11)
            return false;

        var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var tempCpf = cpf.Substring(0, 9);
        var soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        var resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        var digito = resto.ToString();
        tempCpf += digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();

        return cpf.EndsWith(digito);
    }
}

public static class ExtensionMethods
{
    public static string CompleteErroMessage(this Exception e)
    {
        var msg = e.Message;
        if (e.InnerException != null)
        {
            msg += " - " + e.InnerException.Message;
        }
        return msg;
    }
}