namespace EquipmentManagement.ConsoleApp.Core.Files;

public abstract class FileBasedBaseRepository<T> where T : BaseEntity<T>
{
  protected ContextJson context;
  protected List<T> records;

  public FileBasedBaseRepository(ContextJson context)
  {
    this.context = context;
    this.records = LoadRecords();
  }

  protected abstract List<T> LoadRecords();

  public void Register(T entity)
  {
    records.Add(entity);

    context.Save();
  }

  public bool Edit(string selectedId, T updatedEntity)
  {
    T? selectedRegister = FindById(selectedId);

    if (selectedRegister == null)
      return false;

    selectedRegister.UpdateData(updatedEntity);

    context.Save();

    return true;
  }

  public bool Delete(T record)
  {
    bool success = records.Remove(record);

    if (success)
      context.Save();

    return success;
  }

  public bool Delete(string selectedId)
  {
    T? selectedRegister = FindById(selectedId);

    if (selectedRegister == null)
      return false;

    return Delete(selectedRegister);
  }

  public T? FindById(string selectedId)
  {
    foreach (T record in records)
    {
      if (record.Id == selectedId)
        return record;
    }

    return null;
  }

  public List<T> FindAll()
  {
    return records;
  }
}