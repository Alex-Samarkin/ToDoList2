using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList2
{
    public enum ToDoStatusEnum
    {
        Planned,
        InProgress,
        Completed
    }
    public class ToDo
    {
        [DisplayName("Идентификатор"),Description("Условный номер"),DefaultValue(0)]
        public int Id { get; set; } = 0;
        [DisplayName("Название задачи")]
        public string Title { get; set; } = "Задача";
        [DisplayName("Описание задачи")]
        public string Description { get; set; } = "Описание задачи";
        [DisplayName("Дата создания")]
        public DateTime Date { get; set; } = DateTime.Now;
        [DisplayName("Дедлайн")]
        public DateTime Deadline { get; set; } = DateTime.Now;
        [DisplayName("Статус")]
        public ToDoStatusEnum Status { get; set; } = ToDoStatusEnum.Planned;

        /* Так тоже можно - объявить внутри класса
        public enum ToDoStatus
        {
            Planned,
            InProgress,
            Completed
        }
        public ToDoStatus Status2 { get; set; } = ToDoStatus.Planned;
        */

        public override string ToString()
        {
            return $"{Id},{Title},{Description},{Date},{Deadline},{Status}";
        }
        public ToDo() { }

        public ToDo(string line)
        {
            line = line.Trim();
            string[] parts = line.Split(',');
            try
            {
                Id = int.Parse(parts[0]);
                Title = parts[1];
                Description = parts[2];
                Date = DateTime.Parse(parts[3]);
                Deadline = DateTime.Parse(parts[4]);
                Status = (ToDoStatusEnum)Enum.Parse(typeof(ToDoStatusEnum), parts[5]);
            }
            catch
            {
                Id = -1;
                Title = "Задача";
                Description = "Описание задачи";
                Date = DateTime.Now;
                Deadline = DateTime.Now;
                Status = ToDoStatusEnum.Planned;
            }

        }
        
    }
}
