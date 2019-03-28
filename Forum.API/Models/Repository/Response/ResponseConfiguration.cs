﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Models.Repository.Response
{
    /// <summary>
	/// Implements the response entity framework configuration.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{DiscussionResponses}" />
    public class ResponseConfiguration : IEntityTypeConfiguration<DiscussionResponse>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<DiscussionResponse> builder)
        {
            builder.Property(response => response.Response)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasOne(s => s.Discussion)
                .WithMany(g => g.DiscussionResponses)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
