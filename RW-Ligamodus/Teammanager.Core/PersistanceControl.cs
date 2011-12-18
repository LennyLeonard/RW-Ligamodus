using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Teammanager.Core
{
    public class PersistanceControl
    {
        private const string path = @"team_db";
        private const string teamDBpath = @"team_db\teams.xml";
        private const string matchpath = @"match.xml";

        public ObservableCollection<TreeViewChildrenViewModel> deserializeTreeObjects()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TreeViewChildrenViewModel>));
            ObservableCollection<TreeViewChildrenViewModel> _savedTree;
            FileStream file;

            if (File.Exists(teamDBpath))
            {
                try
                {
                    file = new FileStream(teamDBpath, FileMode.Open);
                    _savedTree = (ObservableCollection<TreeViewChildrenViewModel>)serializer.Deserialize(file);

                    return _savedTree;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool serializeTreeObjects(ObservableCollection<TreeViewChildrenViewModel> treeItems)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TreeViewChildrenViewModel>));

            if (!File.Exists(teamDBpath))
            {
                Directory.CreateDirectory(path);
            }

            FileStream file = new FileStream(teamDBpath, FileMode.Create);

            try
            {
                serializer.Serialize(file, treeItems);
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool serializeMatch(Match match)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Match));
            FileStream file = new FileStream(matchpath, FileMode.Create);

            try
            {
                serializer.Serialize(file, match);
                file.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Match deserializeMatch()
        {
            return null;
        }

    }
}
