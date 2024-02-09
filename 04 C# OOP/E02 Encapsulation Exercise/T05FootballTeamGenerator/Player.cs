﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace T05FootballTeamGenerator
{
    public class Player
    {


        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            set
            {
                if (!IsValueInSpectrum(value))
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            set
            {
                if (!IsValueInSpectrum(value))
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            set
            {
                if (!IsValueInSpectrum(value))
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            set
            {
                if (!IsValueInSpectrum(value))
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            set
            {
                if (!IsValueInSpectrum(value))
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
                shooting = value;
            }
        }




        //endurance, sprint, dribble, passing, and shooting
        public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.00;
        private bool IsValueInSpectrum(int value)
        {
            if (value < 0 || value > 100)
            {
                return false;
            }
            return true;
        }


    }
}
