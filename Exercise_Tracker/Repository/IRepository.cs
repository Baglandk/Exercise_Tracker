using System;
namespace Exercise_Tracker.Repository
{
	public interface IRepository<T1, T2> where T1:class
	{
		Task<IEnumerable<T1>> GetAll();
		Task<T1> GetById(T2 Id);
		Task Insert(T1 t1);
		Task Delete(T2 Id);
		Task Update(T1 t1, T2 Id);
		Task Save();
	}
}

