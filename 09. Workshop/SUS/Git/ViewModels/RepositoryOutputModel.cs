﻿using System;

namespace Git.ViewModels
{
    public class RepositoryOutputModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CommitsCount { get; set; }

        public string Owner { get; set; }
    }
}
