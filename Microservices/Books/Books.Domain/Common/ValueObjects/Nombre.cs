using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.Common.ValueObjects
{
    public sealed class Nombre
    {
        public string Valor { get; }

        public Nombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new BussinesRuleException("No deje el nombre en blanco.");

            if (nombre.Length > 90)
                throw new BussinesRuleException("El nombre no puede ser mas largo que 90 caracteres.");

            Valor = nombre.Trim();
        }

        public override string ToString() => Valor;

        public static implicit operator string(Nombre nombre) => nombre.Valor;
    }
}
