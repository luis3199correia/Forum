﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emsa.Mared.Common;
using Emsa.Mared.Common.Database;
using Forum.API.Dtos;
using Forum.API.Models;
using Forum.API.Models.Repository.Discussions;
using Microsoft.EntityFrameworkCore;

namespace Forum.API.Data
{
    /// <inheritdoc />
    public class DiscussionRepository : IDiscussionRepository
    {
        #region [Properties]
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        private readonly DataContext _context;
        #endregion

        #region [Constructors]
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionRepository"/> class.
        /// </summary>
        /// 
        /// <param name="context">The context.</param>
        public DiscussionRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region [Methods] IRepository
        /// <inheritdoc />
        public async Task<Discussion> Create(Discussion discussionToCreate)
        {
            if (string.IsNullOrWhiteSpace(discussionToCreate.Comment))
                throw new ModelException(discussionToCreate.InvalidFieldMessage(p => p.Comment));
            if (string.IsNullOrWhiteSpace(discussionToCreate.UserId.ToString()))
                throw new ModelException(discussionToCreate.InvalidFieldMessage(p => p.UserId));
            if (string.IsNullOrWhiteSpace(discussionToCreate.Subject))
                throw new ModelException(discussionToCreate.InvalidFieldMessage(p => p.Subject));

            discussionToCreate.CreatedDate = DateTime.Now;
            discussionToCreate.Status = "Created";

            await _context.Discussion.AddAsync(discussionToCreate);
            await _context.SaveChangesAsync();

            return discussionToCreate;
        }

        /// <inheritdoc />
        public async Task<List<Discussion>> GetAll()
        {
            var discusssions = this.GetQueryable();

            return await discusssions.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Discussion> Get(long id)
        {
            var discusssion = await _context.Discussion
                .Include(d => d.User)
                .Include(d => d.DiscussionResponses)
                .ThenInclude(r => r.CreatedBy)
                .FirstOrDefaultAsync(x => x.Id == id);

            return discusssion;
        }

        /// <inheritdoc />
        public async Task<Discussion> Update(Discussion updateDiscussion)
        {
            var databaseDiscussion = await _context.Discussion.FindAsync(updateDiscussion.Id);
            if (databaseDiscussion == null)
                throw new ModelException(Discussion.DoesNotExist, true);

            if (string.IsNullOrWhiteSpace(updateDiscussion.Comment))
                throw new ModelException(updateDiscussion.InvalidFieldMessage(p => p.Comment));

            var discussion = await _context.Discussion
                .FirstOrDefaultAsync(x => x.Id == updateDiscussion.Id);

            discussion.Comment = updateDiscussion.Comment;
            discussion.UpdatedDate = DateTime.Now;
            discussion.Status = "Updated";

            await _context.SaveChangesAsync();

            return discussion;
        }

        /// <inheritdoc />
        public async Task Delete(long id)
        {
            var databaseDiscussion = await _context.Discussion.FindAsync(id);
            if (databaseDiscussion == null)
                throw new ModelException(Discussion.DoesNotExist, true);

            var discussion = await _context.Discussion.FindAsync(id);

            discussion.Status = "Removed";
        }

        /// <inheritdoc />
        public async Task<PagedList<Discussion>> GetAll(DiscussionParameters parameters)
        {
            var discussions = this.GetQueryable();

            return await PagedList<Discussion>.CreateAsync(discussions, parameters.PageNumber, parameters.PageSize);
        }

        /// <inheritdoc />
        public Task<bool> Exists(long entityId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [Methods] Utility
        /// <summary>
        /// Gets the queryable.
        /// </summary>
        private IQueryable<Discussion> GetQueryable()
        {
            return _context.Discussion
                .Include(d => d.DiscussionResponses)
                .Include(d => d.User);
        }
        #endregion
    }
}