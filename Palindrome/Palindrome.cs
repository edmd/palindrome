using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palindrome
{
	/// <summary>
	/// We're ignoring any grammatical correctness or case-sensivity of the palindrome
	/// Since we're mimicking full OOO, it would be better to store the computed result 
	/// instead of recalculating it
	/// </summary>
	public class Palindrome : IPalindrome
	{
		private readonly Regex _regex = new("[^a-zA-Z0-9]");
		private Dictionary<char, int> _palindrome;

		public Palindrome(String s)
		{
			_palindrome = new Dictionary<char, int>();

			if(!string.IsNullOrEmpty(s))
			{
				s = _regex.Replace(s, String.Empty).ToLower();

				foreach (char c in s)
				{
					if (_palindrome.ContainsKey(c))
					{
						_palindrome[c] = _palindrome[c] + 1;
					}
					else
					{
						_palindrome.Add(c, 1);
					}
				}
			}
		}

		public async Task<bool> IsPalindrome()
		{
			bool isPalindrome = false;

			if (_palindrome.Count == 1 && _palindrome.Any(x => x.Value > 0))
			{
				return true;
			} else if (_palindrome.Count(x => x.Value % 2 == 1) == 1)
			{
				return true;
			}
			else if (_palindrome.Count > 0 && _palindrome.Count % 2 == 0 && _palindrome.All(x => x.Value % 2 == 0))
			{
				return true;
			}

			return isPalindrome;
		}
	}
}