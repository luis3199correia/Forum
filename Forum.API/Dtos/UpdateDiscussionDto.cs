﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Dtos
{
    /// <summary>
	/// The request data transfer object to update a discussion.
	/// </summary>
    public class UpdateDiscussionDto
    {
        /// <summary>
		/// Gets or sets the Subject.
		/// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
		/// Gets or sets the Comment.
		/// </summary>
        [Required]
        public string Comment { get; set; }
    }
}
