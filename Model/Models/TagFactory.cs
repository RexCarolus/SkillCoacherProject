using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class TagFactory
    {
        public TagFactory(SkillCoacherContext context)
        {
            db = context;
        }
        private SkillCoacherContext db;
        public Tag GetTag(string tagName)
        {
            var returnedTag = new Tag();
            using (var db = new SkillCoacherContext())
            {
                var forametedAddTagName = tagName.Replace(" ", "").ToLower();
                if (db.Tags.Count<Tag>(tag => tag.Name == forametedAddTagName) == 0)
                {
                    returnedTag = db.Tags.Add(new Tag { Name = forametedAddTagName }).Entity;
                }
                else
                {
                    returnedTag = db.Tags.First<Tag>(tag => tag.Name == forametedAddTagName);
                }
                return returnedTag;
            }
        }

        public IEnumerable<Tag> GetTagList(IEnumerable<string> tagNames)
        {
                var tagsList = new List<Tag>();
            foreach (var addTagName in tagNames)
            {
                var forametedAddTagName = String.Format(addTagName.Replace(" ", "").ToLower(), Encoding.UTF8);
                if (db.Tags.Count<Tag>(tag => tag.Name == forametedAddTagName) == 0)
                {
                    var newTag = new Tag { Name = forametedAddTagName };
                    db.Tags.Add(newTag);
                    db.SaveChanges();
                }
                    tagsList.Add(db.Tags.First<Tag>(tag => tag.Name == forametedAddTagName));
            }
            db.SaveChanges();
                return tagsList;
            }
        
    }
}
