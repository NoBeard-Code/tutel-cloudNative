﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Tutel.EduWork.DataAccessLayer.Abstractions.Entities;

namespace Tutel.EduWork.DataAccessLayer.Entities
{
    [PrimaryKey(nameof(UserId), nameof(ProjectId))]
    public class UserProject : IUserRelated
    {
        public string UserId { get; set; }
        public string Position { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; init; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; init; }
    }
}
