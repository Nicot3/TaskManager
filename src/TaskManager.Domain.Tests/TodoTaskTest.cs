using AutoFixture;
using FluentAssertions;
using System.Xml.Linq;
using TaskManager.Domain.TodoTasks;

namespace TaskManager.Domain.Tests
{
    public class TodoTaskTest
    {
        [Fact]
        public void TodoTask_AddTag_ShouldAddTag()
        {
            //Arrange
            var fixture = new Fixture();

            var tag = fixture.Create<string>();
            var todoTask = fixture.Create<TodoTask>();
            //Act
            todoTask.AddTag(tag);
            //Assert
            todoTask.Tags.Should().NotBeEmpty();
            todoTask.Tags.Should().OnlyContain(i => i.Name == tag);
        }

        [Fact]
        public void TodoTask_RemoveTag_ShouldRemoveTag()
        {
            //Arrange
            var fixture = new Fixture();

            var tag = fixture.Create<string>();
            var todoTask = fixture.Create<TodoTask>();
            //Act
            todoTask.AddTag(tag);
            todoTask.RemoveTag(tag);
            //Assert
            todoTask.Tags.Should().BeEmpty();
        }

        [Fact]
        public void TodoTask_AddTagWithExistingTag_ShouldThrowArgumentException()
        {
            //Arrange
            var fixture = new Fixture();

            var tag = fixture.Create<string>();
            var todoTask = fixture.Create<TodoTask>();
            //Act
            todoTask.AddTag(tag);
            Action act = () => todoTask.AddTag(tag);
            //Assert
            todoTask.Tags.Should().NotBeEmpty();
            todoTask.Tags.Should().OnlyContain(i => i.Name == tag);
            act.Should().Throw<ArgumentException>().WithMessage($"Tag with name {tag} already exists");
        }

        [Fact]
        public void TodoTask_RemoveTagWithoutExistingTag_ShouldThrowArgumentException()
        {
            //Arrange
            var fixture = new Fixture();

            var tag = fixture.Create<string>();
            var todoTask = fixture.Create<TodoTask>();
            //Act
            todoTask.AddTag(fixture.Create<string>());
            Action act = () => todoTask.RemoveTag(tag);
            //Assert
            todoTask.Tags.Should().NotBeEmpty();
            todoTask.Tags.Should().NotContain(i => i.Name == tag);

            act.Should().Throw<ArgumentException>().WithMessage($"Tag with name {tag} doesn't exists in the {todoTask.Id} task tags");
        }

        [Fact]
        public void TodoTask_UpdateModifiedDate_ShouldUpdateModifiedDate() {
            //Arrange
            var fixture = new Fixture();

            var tag = fixture.Create<TodoTask>();
            var date = tag.ModifiedDate;
            //Act
            tag.UpdateModifiedDate();
            //Assert
            tag.ModifiedDate.Should().NotBe(date);
        }
    }
}