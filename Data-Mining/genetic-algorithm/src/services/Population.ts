import DNA from "./DNA";
import AbstractPool from "./pools/AbstractPool";
import DefaultPool from "./pools/DefaultPool";

export default class Population {
    private readonly target: string;
    private readonly mutationRate: number;
    private population: DNA[] = [];
    private pool: AbstractPool;
    private generation: number = 0;

    constructor(target: string, mutationRate: number, maxPopulation: number) {
        this.target = target;
        this.mutationRate = mutationRate;
        this.pool = new DefaultPool(this);

        // Create initial population
        for (let i = 0; i < maxPopulation; i++) {
            this.population[i] = DNA.Random(this.target.length);
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
        this.pool.naturalSelection();
    }

    /**
     * Create next generation population
     */
    public generate(): void {
        this.population = this.pool.generate();
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

    public getMutationRate(): number {
        return this.mutationRate;
    }
}