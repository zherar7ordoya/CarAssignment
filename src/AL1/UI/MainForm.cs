using Application;

using Domain;

namespace UI;

public partial class MainForm : Form
{
    private readonly TaskManager _taskManager;

    public MainForm()
    {
        InitializeComponent();
        _taskManager = new TaskManager();
        LoadTasks();
    }

    private void LoadTasks()
    {
        lstTasks.DataSource = null;
        lstTasks.DataSource = _taskManager.GetTasks().ToList();
        lstTasks.DisplayMember = "Description";
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtTask.Text))
        {
            _taskManager.AddTask(txtTask.Text);
            txtTask.Clear();
            LoadTasks();
        }
    }

    private void BtnComplete_Click(object sender, EventArgs e)
    {
        if (lstTasks.SelectedItem is TaskItem task)
        {
            _taskManager.CompleteTask(task.Id);
            LoadTasks();
        }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        if (lstTasks.SelectedItem is TaskItem task)
        {
            _taskManager.DeleteTask(task.Id);
            LoadTasks();
        }
    }
}
