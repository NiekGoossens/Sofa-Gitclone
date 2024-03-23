using Sofa_Gitclone.observer;

namespace Sofa_Gitclone.Test;

public class NotificationTest {
    private Mock<ISubscriber> _subscriberMock;
    
    public NotificationTest() {
        _subscriberMock = new Mock<ISubscriber>();
    }
    
    // [Fact]
    // public void NotifiesSubscriberWhenPublisherPublishes() {
    //     // Arrange
    //     var publisher = new Publisher();
    //     var subscriberMock = new Mock<ISubscriber>();
    //     publisher.Subscribe(subscriberMock.Object);
    //
    //     // Act
    //     publisher.Publish();
    //
    //     // Assert
    //     subscriberMock.Verify(s => s.Notify(), Times.Once);
    // }
    //
    // [Fact]
    // public void DoesNotNotifySubscriberAfterUnsubscribe() {
    //     // Arrange
    //     var publisher = new Publisher();
    //     var subscriberMock = new Mock<ISubscriber>();
    //     publisher.Subscribe(subscriberMock.Object);
    //     publisher.Unsubscribe(subscriberMock.Object);
    //
    //     // Act
    //     publisher.Publish();
    //
    //     // Assert
    //     subscriberMock.Verify(s => s.Notify(), Times.Never);
    // }
    //
    // [Fact]
    // public void DoesNotNotifyUnsubscribedSubscriber() {
    //     // Arrange
    //     var publisher = new Publisher();
    //     var subscriberMock1 = new Mock<ISubscriber>();
    //     var subscriberMock2 = new Mock<ISubscriber>();
    //     publisher.Subscribe(subscriberMock1.Object);
    //     publisher.Subscribe(subscriberMock2.Object);
    //     publisher.Unsubscribe(subscriberMock1.Object);
    //
    //     // Act
    //     publisher.Publish();
    //
    //     // Assert
    //     subscriberMock1.Verify(s => s.Notify(), Times.Never);
    //     subscriberMock2.Verify(s => s.Notify(), Times.Once);
    // }
}