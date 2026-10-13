using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public String nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<String> matieres { get; private set; }

        readonly int capEleves = 30;
        public readonly static int capMatieres = 10;
        public Classe(String pName)
        {
            this.nomClasse = pName;
            this.eleves = new List<Eleve>();
            this.matieres = new List<String>();
        }

        public void ajouterEleve(String pNom, String pPrenom)
        {
            if (eleves.Count >= capEleves)
            {
                Console.WriteLine("Cap Eleves " + capEleves + " atteint pour classe " + nomClasse + ", " + pPrenom + " " + pNom + " non ajouté");
                return;
            }
            Eleve eleve = new Eleve(pNom, pPrenom);
            this.eleves.Add(eleve);
        }

        public void ajouterMatiere(String pMatiere)
        {
            if (matieres.Count >= capMatieres)
            {
                Console.WriteLine("Cap Matieres " + capMatieres + " atteint pour classe " + nomClasse + ", " + pMatiere + " non ajouté");
                return;
            }
            this.matieres.Add(new String(pMatiere));
        }

        public double? moyenneMatiere(int pMatiere)
        {
            double vSomme = 0;
            int vCount = 0;
            foreach (Eleve vEleve in this.eleves)
            {
                double? vEleveMoyenne = vEleve.moyenneMatiere(pMatiere);
                if (vEleveMoyenne != null)
                {
                    vSomme += (double)vEleveMoyenne;
                    vCount++;
                }
            }
            if (vCount > 0)
            {
                return Math.Round(vSomme / vCount, 2, MidpointRounding.ToZero);
            }
            return null;
        }

        public double? moyenneGeneral()
        {
            double vSomme = 0;
            int vCount = 0;
            for (int i=0; i<this.matieres.Count; i++)
            {
                double? vMatiereMoyenne = this.moyenneMatiere(i);
                if (vMatiereMoyenne != null)
                {
                    vSomme += (double)vMatiereMoyenne;
                    vCount++;
                }
            }
            if (vCount > 0)
            {
                return Math.Round(vSomme / vCount, 2, MidpointRounding.ToZero);
            }
            return null;
        }
    }
}
