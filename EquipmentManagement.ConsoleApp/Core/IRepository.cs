namespace EquipmentManagement.ConsoleApp.Core;

public interface IRepository<T> where T : BaseEntity<T>
{
  void Register(T entity);
  bool Edit(string selectedId, T updatedEntity);
  bool Delete(T record);
  T? FindById(string selectedId);
  List<T> FindAll();
}
