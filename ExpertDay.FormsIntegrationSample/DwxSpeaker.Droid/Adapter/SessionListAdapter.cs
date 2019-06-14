using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DwxSpeaker.Models;

namespace DwxSpeaker.Droid.Adapter
{
    public class SessionListAdapter : BaseAdapter
    {

        private Context _context;
        private List<Session> _sessions;

        public SessionListAdapter(Context context, List<Session> sessions)
        {
            _context = context;
            _sessions = sessions;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            SessionListAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as SessionListAdapterViewHolder;

            if (holder == null)
            {
                holder = new SessionListAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.SessionItem, parent, false);
                holder.Title = view.FindViewById<TextView>(Resource.Id.sessionitem_title);
                holder.Track = view.FindViewById<TextView>(Resource.Id.sessionitem_track);
                holder.Time = view.FindViewById<TextView>(Resource.Id.sessionitem_time);
                view.Tag = holder;
            }


            //fill in your items
            var item = _sessions[position];
            holder.Title.Text = item.Title;
            holder.Time.Text = item.Time;
            holder.Track.Text = item.Track;

            return view;
        }
        
        public override int Count
        {
            get
            {
                return _sessions.Count;
            }
        }

    }

    class SessionListAdapterViewHolder : Java.Lang.Object
    {
        public TextView Title { get; set; }
        public TextView Time { get; set; }
        public TextView Track { get; set; }
    }
}