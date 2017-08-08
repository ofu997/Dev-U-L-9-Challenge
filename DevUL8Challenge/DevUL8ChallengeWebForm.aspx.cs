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
			// Count how many rounds
			int Round = 0; 

			// Create+define characters
			Character hero = new Character();
			Character monster = new Character();
		
			hero.Name = "Ant Man, our hero &#x1F601 :-)";
			hero.Health = 100;
			hero.DamageMaximum = 16;
			hero.AttackBonus = false;
			hero.damageSufferred=0;
	
			monster.Name = "Juggernaut, our enemy &#x1F620 >:(";
			monster.Health = 100;
			monster.DamageMaximum = 9;
			monster.AttackBonus = true;
			monster.damageSufferred = 0;

			// Create dice instance
			Dice ourdice = new Dice();

			// Make them fight
			while (hero.Health > 0 && monster.Health > 0)
			{
				int heroAttacks = hero.Attack(ourdice);
				monster.Defend(heroAttacks);

				int monsterAttacks = monster.Attack(ourdice);
				hero.Defend(monsterAttacks);

				Round = Round + 1;
				printStuff(monster, Round);
				printStuff(hero, Round);

			}
			// Displays winner
			displayResult(hero,monster);
		}

		// Displays details by round 
		private void printStuff(Character HeroMon, int Round)
		{
			Label1.Text += String.Format("Round: {0}<br>Name: {1}<br> Health: {2}<br> Maximum damage: {3}<br> Attack bonus: {4}<br> Damage suffered by opponent's attack: {5}<br><br>",
				Round,HeroMon.Name, HeroMon.Health.ToString(), HeroMon.DamageMaximum.ToString(),
				HeroMon.AttackBonus.ToString(), HeroMon.damageSufferred.ToString());
		}

		// for displaying winner
		private void displayResult(Character opp1, Character opp2)
		{
			if (opp1.Health <= 0 && opp2.Health <= 0)
				Label1.Text += String.Format("<p>Both {0} and {1} died", opp1.Name, opp2.Name);
			else if (opp1.Health <= 0)
				Label1.Text += String.Format("<p>{0} defeated {1}", opp2.Name, opp1.Name);
			else
				Label1.Text += String.Format("<p>{0} defeated {1}", opp1.Name, opp2.Name);
		}

		class Character
		{
			public string Name { get; set; }
			public int Health { get; set; }
			public int DamageMaximum { get; set; }
			public bool AttackBonus { get; set; }
			// an extra PROPERTY
			public int damageSufferred { get; set; }

			public int Attack(Dice ourdice)
			{
				ourdice.Sides = DamageMaximum;
				// local variable attackStrength shows attack strength
				int attackStrength = ourdice.Roll();
				return attackStrength;
			}

			public void Defend(int damage)
			{
				// Set additional Character	property (damageSufferred)
				// to damage parameter, which comes from opponent's Attack
				damageSufferred = damage;
				Health = Health - damage;
			}
		}

		class Dice
		{
			public int Sides { get; set; }

			Random randomRoll = new Random();
			public int Roll()
			{	
				return randomRoll.Next(Sides);
			}
		}
	}
}