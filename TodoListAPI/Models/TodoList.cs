﻿using System.ComponentModel.DataAnnotations;

namespace TodoListAPI
{
    public class TodoList
    {
        public int Id { get; set; }
        [Required]
        public string Tlist { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DueDate { get; set; }

    }
}
