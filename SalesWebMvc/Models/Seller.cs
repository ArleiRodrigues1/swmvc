using System;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
	public class Seller
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public DateTime Aniversario {get; set; }
		public double SalarioBase { get; set; }
		public Department Department { get; set; }
		public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();	
	
		
		public Seller(){}
		
		public Seller(int id, string nome, string email, DateTime aniversario, double salarioBase, Department department){
			Id = id;
			Nome = nome;
			Email = email;
			Aniversario = aniversario;
			SalarioBase = salarioBase;
			Department = department;
		}

		public Seller(string nome, string email, DateTime aniversario, double salarioBase, Department department)
		{
			Nome = nome;
			Email = email;
			Aniversario = aniversario;
			SalarioBase = salarioBase;
			Department = department;
		}

		public void AddSales(SalesRecord sr){
			Sales.Add(sr);
		}
		
		public void RemoveSales(SalesRecord sr){
			Sales.Remove(sr);
		}
		
		public double TotalSales(DateTime initial, DateTime final)
		{
			return Sales.Where(sr => sr.Data >= initial && sr.Data <= final).Sum(sr => sr.Amount);
		}		
	}
}