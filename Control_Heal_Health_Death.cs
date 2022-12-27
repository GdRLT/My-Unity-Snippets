
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _totalHealth;
        [SerializeField] private int _attack;
        [SerializeField] private int _healing;


        public int CurrentHealth => _currentHealth;
        public int TotalHealth => _totalHealth;
        public int Attack => _attack;
        public int Healing => _healing;

        public bool Damage(int amount)
        {
            _currentHealth = Math.Max(0, _currentHealth - amount);
            return _currentHealth == 0;
        }

        public void Heal(int amount)
        {
            _currentHealth += amount;
        }
        
        
        //Other Class
        
        public class Player : MonoBehaviour
        {
          private IEnumerator PlayerAttack()
        {
            var isDead = Enemy.Damage(Player.Attack);
        
            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                _state = BattleState.Won;
                StartCoroutine(EndGame());
            }
            else
            {
                _state = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());
            }
        }
        
