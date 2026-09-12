public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // A turns value of 0 or less means infinite turns.
        // The value is not changed, and the person goes back into the queue.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // If more than one turn remains, use one turn
        // and place the person at the back of the queue.
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        // If Turns == 1, this was the person's last turn.
        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}