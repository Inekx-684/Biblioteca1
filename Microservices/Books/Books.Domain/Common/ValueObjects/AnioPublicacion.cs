using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.Common.ValueObjects
{
    public class AnioPublicacion
    {
        public int Valor { get; }

        public AnioPublicacion(int valor)
        {
            int anioActual = DateTime.Now.Year;

            if (valor < 1450) // año aproximado de la imprenta de Gutenberg
                throw new ArgumentException("El año de publicación no puede ser anterior a la invención de la imprenta.");

            if (valor > anioActual)
                throw new ArgumentException("El año de publicación no puede ser en el futuro.");

            Valor = valor;
        }

            public static implicit operator int(AnioPublicacion anio) => anio.Valor;


    }
}
