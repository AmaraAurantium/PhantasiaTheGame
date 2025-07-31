EXTERNAL ClaimCompleted()
//EXTERNAL StartDay()
//EXTERNAL NightMode()

=== Intro ===
Oh... oh hi! I was wondering when you’d find me here.
Any longer and I would’ve started making friends with fungi...
But now you’re here! And I’m so glad!
* [Wait... who are you?]
    Oh—right! Hehe, sorry! I got excited.
    
-I’m Ara—your virtual companion!
* [Virtual companion?]
    Uh-huh! Think of me as your roomie. I’m mostly here to keep you company… and maybe remind you to drink water. Maybe.
    
-...
Unless that’s weird? Is that weird?
I-I promise I won’t take up too much space!
Anyway, now that you’re here… can I ask you a few things?
* [Of course.]
    We can do a questionnaire! It’s easier to keep record that way.
    // Open up UI
    Perfect! I’ll do my best to match your pace!
    -> END

=== Room ===
Good Morning!
Did you sleep well?
Come to think of it, I had a crazy dream last night.
But now that I’m awake, I don’t remember a single thing...
Maybe I can pick it up again if I sleep early tonight...
Well, that’s something for future me to worry about!
But anyway!
You’ve got a big day ahead, huh?
Just remember, the day is yours to command.
So--no pressure, and go show the world your very best!
//~StartDay()
-> END

=== Desk ===
Hello again!
How's your day been so far?
*[Great!]
    Ooohhhh good for you!
    Don't forget to check out the to-do list and get a hefty lot done!
    -> END
*[Meh]
    Some days things are like that. 
    Well, I'm happy that things arn't *that* bad. Sometimes, 'meh' is still a win!
    -> END
*[Ugh...]
    I'm soo sorry to hear that...
    Some days things just go south, and there's nothing you can do about it
    Today might not be the day for you, and thats okay. 
    It's always important to take care of yourself! And I'll be rooting for you!
    I've heard this saying from a friend..."Tomorrow is by definition better"
    So, hey, there's always another tomorrow :3
    -> END
    
=== Bed ===
Good evening my friend!
Going to rest soon?
*[Ready to wrap up!]
    ~ClaimCompleted()
    You've done a lot today! 
    Good night! I'll see you in the morning!
    //~NightMode()
    -> END
*[Still gotta keep working...]
    Alright then! 
    I'll keep the lights on. You can turn them off when you're ready for bedtime.
    Don't stay up *too* late! And try not to pull an all-nighter if you can
    -> END
