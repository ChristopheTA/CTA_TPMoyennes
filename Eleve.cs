using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{

    class Eleve
    {
        public String nom { get; private set; }
        public String prenom { get; private set; }
        public List<Note> notes { get; private set; }

        readonly int capNotes = 200;
        public Eleve(String pNom, String pPrenom)
        {
            this.nom = pNom;
            this.prenom = pPrenom;
            this.notes = new List<Note>();
        }
        public void ajouterNote(Note pNote)
        {
            if (this.notes.Count >= capNotes)
            {
                Console.WriteLine("Cap Notes " + capNotes + " atteint pour eleve " + this.prenom + " " + this.nom + ", " + pNote.matiere + ":" + pNote.note + " non ajouté");
                return;
            }
            this.notes.Add(pNote);
        }
        public double? moyenneMatiere(int pMatiere)
        {
            double vSomme = 0;
            int vCount = 0;
            foreach (Note vNote in this.notes)
            {
                if (vNote.matiere == pMatiere)
                {
                    vSomme += vNote.note;
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
            for (int i = 0; i < Classe.capMatieres; i++)
            {
                double? vMoyenneMatiere = this.moyenneMatiere(i);
                if (vMoyenneMatiere != null)
                {
                    vSomme += (double)vMoyenneMatiere;
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
