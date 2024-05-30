using System.Data;

namespace Bombones.Comun
{
    public interface IDbCommandFactory
    {
        IDbCommand CreateCommand(); // Crea un comando
        // Agrega un parámetro al comando, con el nombre del parámetro (el string con la instrucción sql)
        // y desde dónde toma su valor. Para que sea flexible, el valor debe ser object
        // así permite cualquier tipo de datos.
        void AddParameter(IDbCommand command, string parameterName, object value);
    }
}
