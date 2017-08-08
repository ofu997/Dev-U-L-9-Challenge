using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevUL8Challenge
{
	public partial class DevUL8ChallengeWebForm : System.Web.UI.Page
	{
		

		protected void Page_Load(object sender, EventArgs e)
		{
			int Round = 0; 
			Character hero = new Character();
			Character monster = new Character();

			//&#x1F601 :-)

			hero.Name = "Ant Man, our hero ";
			hero.Health = 100;
			hero.DamageMaximum = 15;
			hero.AttackBonus = false;
			hero.damageSufferred=0;
			// hero.Suffered;

			// &#x1F620 >:(
			monster.Name = "Juggernaut, our enemy ";
			monster.Health = 100;
			monster.DamageMaximum = 10;
			monster.AttackBonus = true;
			monster.damageSufferred = 0;

			//int damageSufferred;

			// add in dice instance
			Dice ourdice = new Dice();

			// bonus!!
			/*
			if (hero.AttackBonus)
			
				monster.Defend(hero.Attack(ourdice));
				//monster.damageSuffered=hero.Attack(ourdice); 
			
			if (monster.AttackBonus)
			
				hero.Defend(monster.Attack(ourdice));
				//hero.damageSuffered = monster.Attack(ourdice);
			*/


			while (hero.Health > 0 && monster.Health > 0)
			{
				int heroAttacks = hero.Attack(ourdice);
				monster.Defend(heroAttacks);
				// values won't update : monster.damageSuffered = hero.Attack(ourdice);

				int monsterAttacks = monster.Attack(ourdice);
				hero.Defend(monsterAttacks);
				// values won't update :hero.damageSuffered = monster.Attack(ourdice);

				// ourdice.Roll().ToString() is updating but seems inaccurate
				Round = Round + 1;
				printStuff(monster, Round);
				printStuff(hero, Round);

			}
			/*
			int damage = hero.Attack(ourdice);
			monster.Defend(damage);
			// an extra PROPERTY
			monster.damageSuffered = damage;

			damage = monster.Attack(ourdice);
			hero.Defend(damage);
			// an extra PROPERTY
			hero.damageSuffered = damage;
			*/
			displayResult(hero,monster);
		}

		private void printStuff(Character HeroMon, int Round)
		{
			Label1.Text += String.Format("Round: {0}<br>Name: {1}<br> Health: {2}<br> Maximum damage: {3}<br> Attack bonus: {4}<br> Damage suffered by opponent's attack: {5}<br><br>",
				Round,HeroMon.Name, HeroMon.Health.ToString(), HeroMon.DamageMaximum.ToString(),
				HeroMon.AttackBonus.ToString(), HeroMon.damageSufferred.ToString());
		}

		// for displaying results
		private void displayResult(Character opp1, Character opp2)
		{
			if (opp1.Health <= 0 && opp2.Health <= 0)
				Label1.Text += String.Format("<p>Both {0} and {1} died", opp1.Name, opp2.Name);
			else if (opp1.Health <= 0)
				Label1.Text += String.Format("<p>{0} defeated {1}", opp1.Name, opp2.Name);
			else
				Label1.Text += String.Format("<p>{0} defeated {1}", opp2.Name, opp1.Name);

		}

		class Character
		{
			public string Name { get; set; }
			public int Health { get; set; }
			public int DamageMaximum { get; set; }
			// what does this do? 
			public bool AttackBonus { get; set; }
			// an extra PROPERTY
			public int damageSufferred { get; set; }

			// move this to the function: Random randomthing = new Random();

			public int Attack(Dice ourdice)
			{
				//int damage = randomthing.Next(0,50);
				//Random randomthing = new Random();
				//int damage = randomThing.Next(DamageMaximum);
				ourdice.Sides = DamageMaximum;

				// local variable damage shows attack strength
				int attackStrength = ourdice.Roll();
				return attackStrength;
			}

			// public int Defend(Character theCharacter)
			public void Defend(int damage)
			{
				damageSufferred = damage;
				// Defend relies on damage property 
				Health = Health - damage;
				// return currentHealth;
				// if goes down by two, display the damage as 2
			}
		}

		class Dice
		{
			public int Sides { get; set; }


			// here?
			Random randomRoll = new Random();
			public int Roll()
			{	
				// or here?
				//Random randomRoll = new Random();
				// int maxvalue = randomRoll.Next(Sides);
				return randomRoll.Next(Sides);
			}
		}


		/*
public int Attack()
{	
	int damage = randomthing.Next(50);
	return damage;
}

public int Defend(int damage, int Health)
{
	int currentHealth=Health-damage;
	return currentHealth;
}
*/
	}
}