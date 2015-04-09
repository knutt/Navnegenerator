﻿using System;
using System.Collections.Generic;
using System.Linq;
using Navnegenerator.Typar.Exceptions;

namespace Navnegenerator.Typar
{
    public class Navneoversikt
    {
        private Random random = new Random();
        private int totaltAntallTal;
        private readonly SortedDictionary<int, string> navna = new SortedDictionary<int, string>();

        public void LeggTilNavn(string navn, int antall)
        {
            navna.Add(totaltAntallTal, navn);
            totaltAntallTal += antall;
        }

        public IEnumerable<string> HentAlleEtternavn()
        {
            return navna.Values;
        }

        public string HentEitNyttTilfeldigNavn()
        {
            if (navna.Count == 0)
                throw new NavnegeneratorException("Kan ikkje generera eit navn når oversikta ikkje har navn.");
            var navnenummer = random.Next(totaltAntallTal);
            return navna.Last(x => x.Key <= navnenummer).Value;
        }
    }
}