using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TMDbDotNet.TmdbApi;

namespace TMDbSampleApp
{
    public partial class FormCastCrew : Form
    {
        public FormCastCrew(MovieCasts casts)
        {
            InitializeComponent();
            
            castGrid.DataSource = casts.cast.OrderBy(c => c.order).Select(c => new
            {
                id = c.id,
                name = c.name,
                character = c.character
            }).ToList();
            crewGrid.DataSource = casts.crew.Select(c => new 
            {
                id = c.id,
                name = c.name,
                department = c.department,
                job = c.job
            }).ToList();
        }
    }
}
