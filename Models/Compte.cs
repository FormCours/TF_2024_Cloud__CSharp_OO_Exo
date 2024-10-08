﻿using Models.Delegate;
using Models.Exceptions;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Compte : IBanker, ICustomer
    {
        #region Champs
        private double _Solde;
        #endregion

        #region Props
        public string Numero { get; private set; }

        public double Solde
        {
            get { return _Solde; }
            private set { _Solde = Math.Round(value, 2); }
        }
        public Personne Titulaire { get; private set; }
        #endregion

        #region Event
        public event Action<Compte> PassageEnNegatifEvent;
        #endregion

        #region constructeurs
        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        public Compte(string numero, Personne titulaire, double solde): this (numero, titulaire)
        {
            Solde = solde;
        }
        #endregion

        #region Méthodes
        public virtual void Depot(double montant)
        {
            RaiseExceptionIfNegatif(montant);

            Solde = Solde + montant;
        }

        public virtual void Retrait(double montant)
        {
            RaiseExceptionIfNegatif(montant);

            Solde = Solde - montant;
        }

        private void RaiseExceptionIfNegatif(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant));
                // throw new ArgumentOutOfRangeException("montant"));
            }
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }

        protected void DeclencherPassageEnNegatifEvent()
        {
            if (PassageEnNegatifEvent != null)
            {
                PassageEnNegatifEvent(this);
            }
        }
        #endregion

        #region Surcharge d'operateur
        public static double operator +(Compte c1, Compte c2)
        {
            double solde1 = c1.Solde > 0 ? c1.Solde : 0;
            double solde2 = Math.Max(c2.Solde, 0);

            return solde1 + solde2;
        }

        public static double operator +(double left, Compte rigth)
        {
            return left + Math.Max(rigth.Solde, 0);
        }

        public static double operator +(Compte rigth, double left)
        {
            return left + rigth;
        }
        #endregion
    }
}
