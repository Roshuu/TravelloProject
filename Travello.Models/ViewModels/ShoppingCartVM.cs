﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello.Models.ViewModels
{
	public class ShoppingCartVM
	{
		public IEnumerable<ShoppingCart> ListCart { get; set; }
	}
}
