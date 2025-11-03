using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEntities;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.FightEntities;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class GameTests
{
    [Fact]

    public void GameTests_ApplyCombinationOfModifiers_BlockDamageAndDoubleAttacked()
    {
        // Arrange
        ICreatureBuilder builder1 = new EvilFighterBuilderFactory(2).Create();
        ICreatureBuilder builder2 = new EvilFighterBuilderFactory(2).Create();

        var magicShieldModifier = new MagicShieldModifierFactory();
        var attackMasteryModifierFactory = new AttackMasteryModifierFactory();

        ICreature evilFighter = builder1.AddModifier(magicShieldModifier).AddModifier(attackMasteryModifierFactory).Build();
        ICreature target = builder2.ChangeHealth(new Health(2)).Build();

        // Act
        evilFighter.TakeDamage(new Damage(5));
        evilFighter.Attack(target);

        // Assert
        Assert.Equal(evilFighter.Health, new Health(6));
        Assert.Equal(target.Health, new Health(0));
    }

    [Fact]

    public void GameTests_ApplyMagicShieldModifier_BlockDamage()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory(2).Create();
        var magicShieldModifier = new MagicShieldModifierFactory();
        ICreature evilFighter = builder.AddModifier(magicShieldModifier).Build();

        // Act
        evilFighter.TakeDamage(new Damage(5));

        // Assert
        Assert.Equal(evilFighter.Health, new Health(6));
    }

    [Fact]

    public void GameTests_ApplyMagicShieldModifier_Disappear()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory(2).Create();
        var magicShieldModifier = new MagicShieldModifierFactory();
        ICreature evilFighter = builder.AddModifier(magicShieldModifier).Build();

        // Act
        evilFighter.TakeDamage(new Damage(5));
        evilFighter.TakeDamage(new Damage(5));

        // Assert
        Assert.Equal(evilFighter.Health, new Health(1));
    }

    [Fact]

    public void GameTests_AttackMasteryModifier_NotMakeDoubleAttack()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory(2).Create();
        var attackMasteryModifierFactory = new AttackMasteryModifierFactory();
        ICreature evilFighter = builder.AddModifier(attackMasteryModifierFactory).ChangeDamage(new Damage(200)).Build();
        ICreature target = builder.Build();

        // Act
        evilFighter.Attack(target);

        // Assert
        Assert.Equal(target.Health, new Health(-194));
    }

    [Fact]

    public void GameTests_AttackMasteryModifier_MakeDoubleAttack()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory(2).Create();
        var attackMasteryModifierFactory = new AttackMasteryModifierFactory();
        ICreature evilFighter = builder.AddModifier(attackMasteryModifierFactory).ChangeDamage(new Damage(5)).Build();
        ICreature target = builder.Build();

        // Act
        evilFighter.Attack(target);

        // Assert
        Assert.Equal(target.Health, new Health(-4));
    }

    [Fact]

    public void GameTests_CombatAnalystAttack_IncreaseDamage()
    {
        // Arrange
        ICreatureBuilder builder1 = new CombatMasterBuilderFactory(new Damage(2)).Create();
        ICreature combatMaster = builder1.Build();

        ICreatureBuilder builder2 = new EvilFighterBuilderFactory(2).Create();
        ICreature target = builder2.Build();

        // Act
        combatMaster.Attack(target);

        // Assert
        Assert.Equal(combatMaster.Damage, new Damage(4));
        Assert.Equal(target.Health, new Health(2));
    }

    [Fact]

    public void GameTests_EvilFighterAttacked_IncreaseDamage()
    {
        // Arrange
        ICreatureBuilder builder1 = new CombatMasterBuilderFactory(new Damage(2)).Create();
        ICreature target = builder1.Build();

        ICreatureBuilder builder2 = new EvilFighterBuilderFactory(2).Create();
        ICreature evilFighter = builder2.Build();

        // Act
        target.Attack(evilFighter);

        // Assert
        Assert.Equal(evilFighter.Damage, new Damage(2));
    }

    [Fact]

    public void GameTests_MimicChestAttacked_StealDamageAndHealth()
    {
        // Arrange
        ICreatureBuilder builder1 = new MimicChestBuilderFactory().Create();
        ICreature mimicChest = builder1.Build();

        ICreatureBuilder builder2 = new EvilFighterBuilderFactory(2).Create();
        ICreature target = builder2.ChangeDamage(new Damage(200)).Build();

        // Act
        mimicChest.Attack(target);

        // Assert
        Assert.Equal(mimicChest.Damage, new Damage(200));
        Assert.Equal(mimicChest.Health, new Health(6));
    }

    [Fact]

    public void GameTests_ImmortalHorrorDiedTwoTimes_ReincarnateAfterFirstDeath()
    {
        // Arrange
        ICreatureBuilder builder1 = new ImmortalHorrorBuilderFactory().Create();
        ICreature immortalHorror = builder1.Build();

        ICreatureBuilder builder2 = new EvilFighterBuilderFactory(2).Create();
        ICreature target = builder2.ChangeDamage(new Damage(200)).Build();

        // Act
        target.Attack(immortalHorror);

        // Assert
        Assert.True(immortalHorror.IsAlive);
        Assert.Equal(immortalHorror.Damage, new Damage(4));
        Assert.Equal(immortalHorror.Health, new Health(1));
    }

    [Fact]

    public void GameTests_AmuletMaster_HasModifiers()
    {
        // Arrange
        ICreatureBuilder builder1 = new AmuletMasterBuilderFactory().Create();
        ICreature amuletMaster = builder1.Build();

        ICreatureBuilder builder2 = new EvilFighterBuilderFactory(2).Create();
        ICreature target = builder2.ChangeDamage(new Damage(200)).Build();

        // Act
        target.Attack(amuletMaster);
        amuletMaster.Attack(target);

        // Assert
        Assert.Equal(amuletMaster.Health, new Health(2));
        Assert.False(target.IsAlive);
    }

    [Fact]

    public void GameTests_StrengthPotion_AttackIncreased()
    {
        // Arrange
        ICreatureBuilder builder = new AmuletMasterBuilderFactory().Create();
        ICreature amuletMaster = builder.Build();
        var strengthPotion = new StrengthPotionSpell();

        // Act
        amuletMaster = strengthPotion.ApplyPotion(amuletMaster);

        // Assert
        Assert.Equal(amuletMaster.Damage, new Damage(10));
    }

    [Fact]

    public void GameTests_StaminaPotion_HealthIncreased()
    {
        // Arrange
        ICreatureBuilder builder = new AmuletMasterBuilderFactory().Create();
        ICreature amuletMaster = builder.Build();
        var staminaPotion = new StaminaPotionSpell();

        // Act
        amuletMaster = staminaPotion.ApplyPotion(amuletMaster);

        // Assert
        Assert.Equal(amuletMaster.Health, new Health(7));
    }

    [Fact]

    public void GameTests_ProtectionAmulet_MagicShieldCasted()
    {
        // Arrange
        ICreatureBuilder builder = new MimicChestBuilderFactory().Create();
        ICreature mimicChest = builder.Build();
        var protectionAmulet = new ProtectionAmuletSpell();

        // Act
        mimicChest = protectionAmulet.ApplyPotion(mimicChest);
        mimicChest.TakeDamage(new Damage(200));

        // Assert
        Assert.Equal(mimicChest.Health, new Health(1));
    }

    [Fact]

    public void GameTests_MagicMirror_HealthAndDamageChanged()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory(2).Create();
        ICreature evilFighter = builder.Build();
        var magicMirrorSpell = new MagicMirrorSpell();

        // Act
        evilFighter = magicMirrorSpell.ApplyPotion(evilFighter);

        // Assert
        Assert.Equal(evilFighter.Health, new Health(1));
        Assert.Equal(evilFighter.Damage, new Damage(6));
    }

    [Fact]

    public void GameTests_AddedEightCreaturesIntoPlayerTable_FirstSevenAddedEighthIgnored()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory(2).Create();
        ICreature evilFighter1 = builder.Build();
        ICreature evilFighter2 = builder.Build();
        ICreature evilFighter3 = builder.Build();
        ICreature evilFighter4 = builder.Build();
        ICreature evilFighter5 = builder.Build();
        ICreature evilFighter6 = builder.Build();
        ICreature evilFighter7 = builder.Build();
        ICreature evilFighter8 = builder.Build();

        var playerTable = new PlayerTable();

        // Act
        AddCreatureResultType res1 = playerTable.AddCreature(evilFighter1);
        AddCreatureResultType res2 = playerTable.AddCreature(evilFighter2);
        AddCreatureResultType res3 = playerTable.AddCreature(evilFighter3);
        AddCreatureResultType res4 = playerTable.AddCreature(evilFighter4);
        AddCreatureResultType res5 = playerTable.AddCreature(evilFighter5);
        AddCreatureResultType res6 = playerTable.AddCreature(evilFighter6);
        AddCreatureResultType res7 = playerTable.AddCreature(evilFighter7);
        AddCreatureResultType res8 = playerTable.AddCreature(evilFighter8);

        // Assert
        Assert.Equal(res1, new AddCreatureResultType.CreatureAdded());
        Assert.Equal(res2, new AddCreatureResultType.CreatureAdded());
        Assert.Equal(res3, new AddCreatureResultType.CreatureAdded());
        Assert.Equal(res4, new AddCreatureResultType.CreatureAdded());
        Assert.Equal(res5, new AddCreatureResultType.CreatureAdded());
        Assert.Equal(res6, new AddCreatureResultType.CreatureAdded());
        Assert.Equal(res7, new AddCreatureResultType.CreatureAdded());
        Assert.Equal(res8, new AddCreatureResultType.LimitReached(7));
    }

    [Fact]

    public void GameTests_AddedCreatureIntoPlayerTableWithNegativeHealth_NotReceivedAttackingAndAttackedCreature()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory(2).Create();
        ICreature evilFighter = builder.Build();
        evilFighter.SetHealth(new Health(-2));

        var playerTable = new PlayerTable();

        // Act
        playerTable.AddCreature(evilFighter);
        ICreature? res1 = playerTable.FindAttackingCreature();
        ICreature? res2 = playerTable.FindAttackedCreature();

        // Assert
        Assert.Null(res1);
        Assert.Null(res2);
    }

    [Fact]

    public void GameTests_StartFight_Player1Win()
    {
        // Arrange
        ICreatureBuilder builder1 = new EvilFighterBuilderFactory(2).Create();
        ICreatureBuilder builder2 = new EvilFighterBuilderFactory(2).Create();
        ICreature evilFighter1 = builder1.ChangeHealth(new Health(200)).ChangeDamage(new Damage(200)).Build();
        ICreature evilFighter2 = builder2.Build();

        var playerTable1 = new PlayerTable();
        var playerTable2 = new PlayerTable();

        playerTable1.AddCreature(evilFighter1);
        playerTable2.AddCreature(evilFighter2);

        var fight = new Fight(playerTable1, playerTable2);

        // Act
        FightResult res = fight.Simulation();

        // Assert
        Assert.Equal(FightResult.Player1Win, res);
    }

    [Fact]

    public void GameTests_StartFight_Draw()
    {
        // Arrange
        var playerTable1 = new PlayerTable();
        var playerTable2 = new PlayerTable();

        var fight = new Fight(playerTable1, playerTable2);

        // Act
        FightResult res = fight.Simulation();

        // Assert
        Assert.Equal(FightResult.Draw, res);
    }

    [Fact]

    public void GameTests_ApplyPotionOnCreatureIntoTable_Applied()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory().Create();
        ICreature evilFighter = builder.Build();

        var playerTable = new PlayerTable();

        ISpell strengthPotion = new StrengthPotionSpell();

        playerTable.AddCreature(evilFighter);

        // Act
        SpellCastResult res = playerTable.ApplyPotion(strengthPotion, evilFighter);
        ICreature? creature = playerTable.FindAttackingCreature();
        Assert.NotNull(creature);

        // Assert
        Assert.Equal(SpellCastResult.Casted, res);
        Assert.Equal(creature.Damage, new Damage(6));
    }

    [Fact]

    public void GameTests_ApplyPotionOnNotAddedCreature_NotApplied()
    {
        // Arrange
        ICreatureBuilder builder = new EvilFighterBuilderFactory().Create();
        ICreature evilFighter1 = builder.Build();
        ICreature evilFighter2 = builder.Build();

        var playerTable = new PlayerTable();

        ISpell strengthPotion = new StrengthPotionSpell();

        playerTable.AddCreature(evilFighter1);

        // Act
        SpellCastResult res = playerTable.ApplyPotion(strengthPotion, evilFighter2);

        // Assert
        Assert.Equal(SpellCastResult.NotCasted, res);
    }

    [Fact]

    public void GameTests_AddedTwoPlayerTablesIntoFight_TrulyCloned()
    {
        ICreatureBuilder builder1 = new EvilFighterBuilderFactory().Create();
        ICreatureBuilder builder2 = new EvilFighterBuilderFactory().Create();
        ICreature evilFighter1 = builder1.Build();
        ICreature evilFighter2 = builder2.Build();

        var playerTable1 = new PlayerTable();
        var playerTable2 = new PlayerTable();

        playerTable1.AddCreature(evilFighter1);
        playerTable2.AddCreature(evilFighter2);

        var fight = new Fight(playerTable1, playerTable2);

        // Act
        FightResult res = fight.Simulation();

        // Assert
        Assert.Equal(FightResult.Player2Win, res);
        Assert.Equal(evilFighter1.Health, new Health(6));
        Assert.Equal(evilFighter2.Health, new Health(6));
    }
}