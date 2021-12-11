using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class TagFactory
    {
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
            using (var db = new SkillCoacherContext())
            {
                var tagsList = new List<Tag>();
                foreach (var addTagName in tagNames)
                {
                    var forametedAddTagName = addTagName.Replace(" ", "").ToLower();
                    if (db.Tags.Count<Tag>(tag => tag.Name == forametedAddTagName) == 0)
                    {
                        tagsList.Add(db.Tags.Add(new Tag { Name = forametedAddTagName }).Entity);
                    }
                    else
                    {
                        tagsList.Add(db.Tags.First<Tag>(tag => tag.Name == forametedAddTagName));
                    }

                }

                return tagsList;
            }
        }
    }
}
