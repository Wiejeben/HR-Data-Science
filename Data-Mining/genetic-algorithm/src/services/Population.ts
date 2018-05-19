import DNA from "./DNA";

export default class Population {
    private readonly target: string;
    private mutationRate: number;
    private population: DNA[] = [];
    private matingPool: DNA[] = [];
    private generation: number = 0;

    constructor(target: string, mutationRate: number, maxPopulation: number) {
        this.target = target;
        this.mutationRate = mutationRate;

        // Create initial population
        for (let i = 0; i < maxPopulation; i++) {
            this.population[i] = new DNA(this.target.length);
        }
    }

    /**
     * Calculate new fitness score of the population.
     */
    public calcFitness(): void {
        this.population.forEach(dna => dna.calcFitness(this.target));
    }

    /**
     * Generate mating pool.
     */
    public naturalSelection(): void {
        this.matingPool = [];

        for (const dna of this.population) {
            const n = (dna.fitness / this.best().fitness) * 100;
            for (let j = 0; j < n; j++) {
                this.matingPool.push(dna);
            }
        }
    }

    /**
     * Create next generation population
     */
    public generate(): void {
        for (let i = 0; i < this.population.length; i++) {
            const left = this.matingPool[Math.floor(this.randomNumber(0, this.matingPool.length - 1))];
            const right = this.matingPool[Math.floor(this.randomNumber(0, this.matingPool.length - 1))];

            const child = left.crossover(right);
            child.mutate(this.mutationRate);

            // Overwrite existing population
            this.population[i] = child;
        }
        this.generation++;
    }

    /**
     * Calculate average fitness.
     *
     * @return {number}
     */
    public averageFitness(): number {
        const sum = this.population
            .map(dna => dna.fitness)
            .reduce((total, current) => total + current, 0);

        return sum / this.population.length;
    }

    /**
     * Get best DNA item.
     *
     * @return {DNA}
     */
    public best(): DNA {
        return this.population.reduce((prev, current) => (prev.fitness > current.fitness) ? prev : current);
    }

    /**
     * Get list of DNA.
     *
     * @return {DNA[]}
     */
    public getPopulation(): DNA[] {
        return this.population;
    }

    public getGeneration(): number {
        return this.generation;
    }

    private randomNumber(min: number, max: number): number {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}