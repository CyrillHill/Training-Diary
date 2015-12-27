using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;

namespace Training_Diary
{
    public class MySerialization: MetroWindow
    {
        
        public void Serialize(ObservableCollection<UserTraining> sp)
        {
            Stream stream = File.Open("data.bin", FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            try
            {
                bin.Serialize(stream, sp);
            }
            catch (Exception e)
            {
                DialogService.ShowMessage(e.ToString());
            }
            finally
            {
                DialogService.ShowMessage("Сохранение завершено");
                stream.Close();
            }

        }
        public ObservableCollection<UserTraining> DeSerialize()
        {
            FileStream fs = new FileStream("data.bin", FileMode.Open);

            ObservableCollection<UserTraining> my = null;
            try
            {

                {
                    BinaryFormatter bin = new BinaryFormatter();
                    my = (ObservableCollection<UserTraining>)bin.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                DialogService.ShowMessage(e.ToString());
            }
            finally
            {
                DialogService.ShowMessage("Загрузка завершена");
                fs.Close();

            }
            return my;
        }
    }
}
